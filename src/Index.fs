/// This is the main entry point to the program. This is what ties all the
/// different pages together and link all their functionality. This is the
/// main content that is being served to the index.html file.

module App.Index

open Elmish

open App
open App.Pages
open App.Router


// ---- Types ------------------------------------------------------------------

[<RequireQualifiedAccess>]
type Page =
    | Home of Home.State
    | NotFound


type State =
    { ActivePage: Page
      CurrentRoute: Route option
      Device: Responsive.Device }

type Msg =
    | HomeMsg of Home.Msg
    | BrowserResize of Responsive.Device


// ---- Data Handling ----------------------------------------------------------

let rec setRoute (optRoute: Route option) model =
    let model = { model with CurrentRoute = optRoute }
    let navigate = Router.navigateTo optRoute

    match optRoute with
    | None -> { model with ActivePage = Page.NotFound }, Cmd.none
    | Some route ->
        match route with

        | Route.Home ->
            let homeModel = Home.init ()

            { model with ActivePage = Page.Home homeModel }, navigate

let init (location: Route option) : State * Cmd<Msg> =
    setRoute
        location
        { ActivePage = Home.init () |> Page.Home
          CurrentRoute = None
          Device = Responsive.device () }

let update (msg: Msg) (state: State) : State * Cmd<Msg> =
    match state.ActivePage, msg with
    | _, BrowserResize newDevice -> { state with Device = newDevice }, Cmd.none
    | Page.NotFound, _ -> state, Cmd.none

    | Page.Home homeState, HomeMsg homeMsg ->
        let newHomeState = Home.update homeMsg homeState
        { state with ActivePage = Page.Home newHomeState }, Cmd.none


// ---- Views ------------------------------------------------------------------

let view (state: State) (dispatch: Msg -> unit) =
    match state.ActivePage with
    | Page.Home homeState -> Home.view homeState (HomeMsg >> dispatch)
    | Page.NotFound -> NotFound.view ()
