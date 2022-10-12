module App.Views.FloatingGrid

open Feliz
open Feliz.Bulma

let inColumns (count: int) (content: ReactElement list) : ReactElement =
    let columns: ReactElement list list =
        List.splitInto count content

    let verticalTile (subElements: ReactElement list) =
        Bulma.column [
            prop.children (subElements |> List.map Bulma.block)
        ]

    Bulma.columns [
        prop.children (List.map verticalTile columns)
    ]

let inGrid (count: int) (content: ReactElement list) : ReactElement =
    let size =
        match count with
        | 1 -> column.is12
        | 2 -> column.is6
        | 3 -> column.is4
        | 4 -> column.is3
        | 6 -> column.is2
        | 12 -> column.is1
        | _ ->
            failwith (
                "FloatingGrid doesn't support a grid size of "
                + string count
                + ", pick a different grid size."
            )


    let chunkedColumns: ReactElement list list =
        List.chunkBySize count content

    let singleTile (e: ReactElement) =
        Bulma.column [
            size
            prop.children [ e ]
        ]

    let verticalTile (subElements: ReactElement list) =
        Bulma.columns [
            columns.isCentered
            prop.children (List.map singleTile subElements)
        ]

    Html.div [
        prop.children (List.map verticalTile chunkedColumns)
    ]
