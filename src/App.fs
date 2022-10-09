module App

open Elmish
open Elmish.React
open Feliz
open Feliz.Bulma
open App

type State = { Count: int }

type Msg =
    | Increment
    | Decrement

let init () = { Count = 0 }

let update (msg: Msg) (state: State) : State =
    match msg with
    | Increment -> { state with Count = state.Count + 1 }

    | Decrement -> { state with Count = state.Count - 1 }

let navigation: ReactElement =
    Bulma.navbarMenu [
        Bulma.navbarStart.div [
            Bulma.navbarItem.a [ prop.text "Home" ]
            Bulma.navbarItem.a [
                prop.text "Projects"
            ]
            Bulma.navbarItem.a [
                prop.text "Gallery"
            ]
            Bulma.navbarItem.a [
                prop.text "Github"
            ]
        ]
        Bulma.navbarEnd.div [
            Bulma.navbarItem.div [
                Bulma.buttons [
                    Bulma.button.a [
                        Bulma.color.isPrimary
                        prop.children [ Html.strong "Sign up" ]
                    ]
                    Bulma.button.a [ prop.text "Log In" ]
                ]
            ]
        ]
    ]

let bodyView: ReactElement =
    let title =
        Bulma.heroBody [
            Bulma.title [
                title.is1
                prop.text "Thomas G Waters"
                text.hasTextCentered
            ]
        ]

    let cards = Cards.view

    Bulma.hero [
        prop.children [ title; cards ]
    ]

let view (state: State) (dispatch: Msg -> unit) : ReactElement =
    Bulma.container [ navigation; bodyView ]

Program.mkSimple init update view
|> Program.withReactSynchronous "App"
|> Program.run
