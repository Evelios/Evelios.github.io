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
    | Home of Home.Model
    | NotFound


type Model =
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

let init (location: Route option) : Model * Cmd<Msg> =
    setRoute
        location
        { ActivePage = Home.init () |> Page.Home
          CurrentRoute = None
          Device = Responsive.device () }

let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
    match model.ActivePage, msg with
    | _, BrowserResize newDevice -> { model with Device = newDevice }, Cmd.none
    | Page.NotFound, _ -> model, Cmd.none

    | Page.Home homeModel, HomeMsg homeMsg ->
        let newHomeModel = Home.update homeMsg homeModel
        { model with ActivePage = Page.Home newHomeModel }, Cmd.none


// ---- Views ------------------------------------------------------------------

let view (model: Model) (dispatch: Msg -> unit) =
    match model.ActivePage with
    | Page.Home homeModel -> Home.view homeModel (HomeMsg >> dispatch)
    | Page.NotFound -> NotFound.view ()
