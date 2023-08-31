/// Image gallery to show all the artwork that I have created.
module App.Pages.Gallery

open Feliz
open Feliz.Bulma

open App
open App.Router
open App.Components

/// View for a single gallery image. This also includes the event trigger for
/// when a gallery image is clicked.
let private galleryImage (onClick: GalleryImage -> unit) (img: GalleryImage) =
    Bulma.box
        [ prop.onClick (fun _ -> onClick img)
          prop.style [ style.padding 0; style.width.unset ]
          prop.children
              [ Bulma.cardImage
                    [ Bulma.image
                          [ Html.img
                                [ prop.style [ style.cursor.pointer ]
                                  prop.src (Router.Image.gallery img.Source) ] ] ] ] ]

/// The view for a single artwork which appears in a modal
let private modalImage (img: GalleryImage) =
    Bulma.card
        [ Bulma.cardImage [ Bulma.image [ Html.img [ prop.src (Router.Image.gallery img.Source) ] ] ]
          Bulma.cardContent
              [ prop.children
                    [ Bulma.cardHeaderTitle.p [ cardHeaderTitle.isCentered; prop.text img.Title ]
                      Bulma.text.p [ text.hasTextCentered; prop.text img.Description ] ] ] ]


/// Modal view which overlays the entire screen to view a single piece of
/// artwork with it's title and description. This modal needs to be added
/// as a top level element in the DOM because when it is there, it can take
/// over the whole screen.
///
/// TODO: Use absolute positioning and Z-Depth instead of pushing it to the top
let modal (img: GalleryImage) (onClose: unit -> unit) : ReactElement =
    let close _ = onClose ()

    Bulma.modal
        [ prop.id "modal-sample"
          modal.isActive
          prop.children
              [ Bulma.modalBackground [ prop.onClick close ]
                Bulma.modalContent [ prop.style [ style.overflow.hidden ]; prop.children [ modalImage img ] ]
                Bulma.modalClose [ prop.onClick close ] ] ]

let imageGallery (browserSize: Responsive.Device) (onClick: GalleryImage -> unit) : ReactElement =
    let columns =
        match browserSize with
        | Responsive.Mobile -> 1
        | Responsive.Tablet -> 2
        | Responsive.Desktop -> 3

    FloatingGrid.inColumns columns (List.map (galleryImage onClick) WebData.galleryImages)

let view (browserSize: Responsive.Device) (onClick: GalleryImage -> unit) : ReactElement =
    let bodySection (name: string) (content: ReactElement) : ReactElement =
        let title = Bulma.title [ title.is1; prop.text name; text.hasTextCentered ]
        Bulma.section [ title; content ]

    let gallery = imageGallery browserSize onClick

    bodySection "Gallery" gallery
