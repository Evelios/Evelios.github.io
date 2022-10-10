module App.Icon

open Feliz
open Feliz.Bulma

let private fontawesome (name: string) (icon: string) =
    Bulma.iconText [
        Bulma.icon [
            Html.i [prop.className icon]
        ]
        Html.span name
    ]

let github = fontawesome "Github" "fa-brands fa-github"

