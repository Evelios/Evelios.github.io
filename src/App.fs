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


let bodySection (name: string) (content: ReactElement) : ReactElement =
    let title =
        Bulma.title [
            title.is1
            prop.text name
            text.hasTextCentered
        ]

    Bulma.section [ title; content ]

let view (state: State) (dispatch: Msg -> unit) : ReactElement =
    let divider = Bulma.navbarDivider []
    
    let body =
        Html.div [
            bodySection "Interactive Demos" InteractiveDemos.view
            divider
            bodySection "Gallery Images" Gallery.view
        ]

    Bulma.container [ Menu.view; body ]



Program.mkSimple init update view
|> Program.withReactSynchronous "App"
|> Program.run
