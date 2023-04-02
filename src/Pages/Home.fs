module App.Pages.Home

open System
open Feliz
open Feliz.Bulma

open App
open App.Views

type State =
    { GalleryImage: GalleryImage option
      Size: Responsive.Device }

type Msg =
    | SelectGalleryImage of GalleryImage
    | CloseGalleryImage
    | BrowserResize of Responsive.Device

let init () : State =
    { GalleryImage = None
      Size = Responsive.device () }

let update (msg: Msg) (state: State) : State =
    match msg with
    | SelectGalleryImage galleryImage -> { state with GalleryImage = Some galleryImage }
    | CloseGalleryImage -> { state with GalleryImage = None }
    | BrowserResize size -> { state with Size = size }

let bodySection (name: string) (content: ReactElement) : ReactElement =
    let title = Bulma.title [ title.is1; prop.text name; text.hasTextCentered ]

    Bulma.section [ title; content ]

let footer: ReactElement =
    let copyright: string =
        "© " + string DateTime.Now.Year + " Thomas G. Waters, All Rights Reserved"

    Bulma.footer [ text.hasTextCentered; prop.children [ Bulma.text.p copyright ] ]


let view (state: State) (dispatch: Msg -> unit) : ReactElement =
    let divider = Bulma.navbarDivider []

    let body =
        Html.div
            [ bodySection "Gallery Images" (Gallery.view state.Size (SelectGalleryImage >> dispatch))
              divider
              bodySection "Interactive Demos" (InteractiveDemos.view state.Size) ]

    let modal =
        state.GalleryImage
        |> Option.map (fun img -> Gallery.modal img (fun _ -> dispatch CloseGalleryImage))
        |> Option.toList

    Html.div [ yield! modal; Bulma.container [ Menu.view (); body ]; footer ]
