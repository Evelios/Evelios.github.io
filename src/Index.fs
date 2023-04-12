/// This is the main entry point to the program. This is what ties all the
/// different pages together and link all their functionality. This is the
/// main content that is being served to the index.html file.

module App.Index

open System
open Elmish
open Feliz
open Feliz.Bulma

open App
open App.Pages
open App.Views
open App.Router


// ---- Types ------------------------------------------------------------------

[<RequireQualifiedAccess>]
type Page =
    | Home
    | Gallery
    | Demos
    | NotFound


type Model =
    { ActivePage: Page
      CurrentRoute: Route option
      Device: Responsive.Device
      SelectedImage: GalleryImage option }

type Msg =
    | BrowserResize of Responsive.Device
    | SelectedGalleryImage of GalleryImage
    | CloseGalleryModal


// ---- Data Handling ----------------------------------------------------------

let rec setRoute (optRoute: Route option) model =
    let model = { model with CurrentRoute = optRoute }
    let navigate = Router.navigateTo optRoute

    match optRoute with
    | None -> { model with ActivePage = Page.NotFound }, Cmd.none
    | Some route ->
        match route with
        | Route.Home -> { model with ActivePage = Page.Home }, navigate
        | Route.Gallery -> { model with ActivePage = Page.Gallery }, navigate
        | Route.Demos -> { model with ActivePage = Page.Demos }, navigate

let init (location: Route option) : Model * Cmd<Msg> =
    setRoute
        location
        { ActivePage = Page.Home
          CurrentRoute = None
          Device = Responsive.device ()
          SelectedImage = None }

let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
    match msg with
    | BrowserResize newDevice -> { model with Device = newDevice }, Cmd.none
    | SelectedGalleryImage galleryImage -> { model with SelectedImage = Some galleryImage }, Cmd.none
    | CloseGalleryModal -> { model with SelectedImage = None }, Cmd.none



// ---- Views ------------------------------------------------------------------

let footer: ReactElement =
    let copyright: string =
        "© " + string DateTime.Now.Year + " Thomas G. Waters, All Rights Reserved"

    Bulma.footer [ text.hasTextCentered; prop.children [ Bulma.text.p copyright ] ]

let view (model: Model) (dispatch: Msg -> unit) =
    let body =
        match model.ActivePage with
        | Page.Home -> Home.view model.Device (SelectedGalleryImage >> dispatch)
        | Page.Gallery -> Gallery.view model.Device (SelectedGalleryImage >> dispatch)
        | Page.Demos -> Demos.view model.Device
        | Page.NotFound -> NotFound.view ()

    let modal: ReactElement option =
        model.SelectedImage
        |> Option.map (fun img -> Gallery.modal img (fun () -> dispatch CloseGalleryModal))

    Html.div [ yield! (Option.toList modal); Bulma.container [ Menu.view (); body ]; footer ]
