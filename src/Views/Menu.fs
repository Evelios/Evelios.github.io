module App.Views.Menu

open Fable.React
open Feliz
open Feliz.Bulma

let view: ReactElement =
    Bulma.navbarMenu [
        Bulma.navbarStart.div [
            Bulma.navbarItem.div [
                Bulma.title [
                    title.is6
                    prop.text "Thomas G. Waters"
                ]
            ]
            Bulma.navbarItem.a [ prop.text "Home" ]
            Bulma.navbarItem.a [
                prop.text "Projects"
            ]
            Bulma.navbarItem.a [
                prop.text "Gallery"
            ]
        ]
        Bulma.navbarEnd.div [
            Bulma.navbarItem.a [
                prop.text "Github"
            ]
        ]
    ]
