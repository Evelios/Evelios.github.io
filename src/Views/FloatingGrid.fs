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
        | 1 -> tile.is12
        | 2 -> tile.is6
        | 3 -> tile.is4
        | 4 -> tile.is3
        | 6 -> tile.is2
        | 12 -> tile.is1
        | _ ->
            failwith (
                "FloatingGrid doesn't support a grid size of "
                + string count
                + ", pick a different grid size."
            )


    let columns: ReactElement list list =
        List.splitInto count content

    let singleTile (e: ReactElement) =
        Bulma.tile [
            tile.isChild
            prop.children [ e ]
        ]

    let verticalTile (subElements: ReactElement list) =
        Bulma.tile [
            tile.isParent
            tile.isVertical
            size
            prop.children (List.map singleTile subElements)
        ]

    Bulma.tile [
        tile.isAncestor
        prop.children (List.map verticalTile columns)
    ]
