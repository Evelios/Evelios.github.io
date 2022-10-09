module App

open Elmish
open Elmish.React
open Feliz
open Feliz.Bulma
open App.Views

type State = { Count: int }

type Msg =
    | Increment
    | Decrement

let init () = { Count = 0 }

let update (msg: Msg) (state: State) : State =
    match msg with
    | Increment -> { state with Count = state.Count + 1 }

    | Decrement -> { state with Count = state.Count - 1 }

let bodyView: ReactElement =
    let title =
        Bulma.title [
            title.is1
            prop.text "Interactive Demos"
            text.hasTextCentered
        ]

    let cards = InteractiveDemos.view

    Bulma.container [
        Bulma.heroHead title
        Bulma.heroBody cards
    ]

let view (state: State) (dispatch: Msg -> unit) : ReactElement = Html.div [ Menu.view; bodyView ]



Program.mkSimple init update view
|> Program.withReactSynchronous "App"
|> Program.run
