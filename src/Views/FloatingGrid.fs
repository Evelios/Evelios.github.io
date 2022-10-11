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
