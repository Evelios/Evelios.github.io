module App

open System
open Elmish
open Elmish.React
open Feliz
open Feliz.Bulma

open App
open App.Views

type State = { GalleryImage: GalleryImage option }

type Msg =
    | SelectGalleryImage of GalleryImage
    | CloseGalleryImage

let init () = { GalleryImage = None }

let update (msg: Msg) (state: State) : State =
    match msg with
    | SelectGalleryImage galleryImage -> { state with GalleryImage = Some galleryImage }
    | CloseGalleryImage -> { state with GalleryImage = None }



// ---- Views ------------------------------------------------------------------


let bodySection (name: string) (content: ReactElement) : ReactElement =
    let title =
        Bulma.title [
            title.is1
            prop.text name
            text.hasTextCentered
        ]

    Bulma.section [ title; content ]

let footer: ReactElement =
    let text: string =
        "© "
        + string DateTime.Now.Year
        + " Thomas G. Waters, All Rights Reserved"

    Bulma.footer [
        Bulma.content [
            Bulma.text.p [
                Bulma.text.hasTextCentered
                prop.text text
            ]
        ]
    ]

let view (state: State) (dispatch: Msg -> unit) : ReactElement =
    let divider = Bulma.navbarDivider []

    let body =
        Html.div [
            bodySection "Interactive Demos" InteractiveDemos.view
            divider
            bodySection "Gallery Images" (Gallery.view (SelectGalleryImage >> dispatch))
        ]

    let modal =
        state.GalleryImage
        |> Option.map (fun img -> Gallery.modal img (fun _ -> dispatch CloseGalleryImage))
        |> Option.toList

    Html.div [
        yield! modal
        Bulma.container [ Menu.view; body ]
        footer
    ]


Program.mkSimple init update view
|> Program.withReactSynchronous "App"
|> Program.run
