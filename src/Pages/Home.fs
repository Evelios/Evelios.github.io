module App.Pages.Home

open System
open Feliz
open Feliz.Bulma

open App
open App.Views

type Model =
    { GalleryImage: GalleryImage option
      Size: Responsive.Device }

type Msg =
    | SelectGalleryImage of GalleryImage
    | CloseGalleryImage
    | BrowserResize of Responsive.Device

let init () : Model =
    { GalleryImage = None
      Size = Responsive.device () }

let update (msg: Msg) (model: Model) : Model =
    match msg with
    | SelectGalleryImage galleryImage -> { model with GalleryImage = Some galleryImage }
    | CloseGalleryImage -> { model with GalleryImage = None }
    | BrowserResize size -> { model with Size = size }

let bodySection (name: string) (content: ReactElement) : ReactElement =
    let title = Bulma.title [ title.is1; prop.text name; text.hasTextCentered ]

    Bulma.section [ title; content ]

let footer: ReactElement =
    let copyright: string =
        "© " + string DateTime.Now.Year + " Thomas G. Waters, All Rights Reserved"

    Bulma.footer [ text.hasTextCentered; prop.children [ Bulma.text.p copyright ] ]


let view (model: Model) (dispatch: Msg -> unit) : ReactElement =
    let divider = Bulma.navbarDivider []

    let body =
        Html.div
            [ bodySection "Gallery Images" (Gallery.view model.Size (SelectGalleryImage >> dispatch))
              divider
              bodySection "Interactive Demos" (InteractiveDemos.view model.Size) ]

    let modal =
        model.GalleryImage
        |> Option.map (fun img -> Gallery.modal img (fun _ -> dispatch CloseGalleryImage))
        |> Option.toList

    Html.div [ yield! modal; Bulma.container [ Menu.view (); body ]; footer ]
