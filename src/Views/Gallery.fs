module App.Views.Gallery

open Feliz
open Feliz.Bulma

open App

let private galleryImage (onClick: GalleryImage -> unit) (img: GalleryImage) =
    Bulma.box [
        prop.onClick (fun _ -> onClick img)
        prop.className "gallery"
        prop.style [ style.padding 0 ]
        prop.children [
            Bulma.cardImage [
                Bulma.image [
                    Html.img [
                        prop.style [ style.cursor.pointer ]
                        prop.src (Route.Image.gallery img.Source)
                    ]
                ]
            ]
        ]
    ]

let private modalImage (img: GalleryImage) =
    Bulma.card [

        Bulma.cardImage [
            Bulma.image [
                Html.img [
                    prop.src (Route.Image.gallery img.Source)
                ]
            ]
        ]
        Bulma.cardContent [
            prop.children [
                Bulma.cardHeaderTitle.p [
                    cardHeaderTitle.isCentered
                    prop.text img.Title
                ]
                Bulma.text.p [
                    text.hasTextCentered
                    prop.text img.Description
                ]
            ]
        ]
    ]


let modal (img: GalleryImage) (onClose: unit -> unit) : ReactElement =
    let close _ = onClose ()

    Bulma.modal [
        prop.id "modal-sample"
        modal.isActive
        prop.children [
            Bulma.modalBackground [
                prop.onClick close
            ]
            Bulma.modalContent [
                prop.style [ style.overflow.hidden ]
                prop.children [ modalImage img ]
            ]
            Bulma.modalClose [ prop.onClick close ]
        ]
    ]

let view (onClick: GalleryImage -> unit) =
    let galleryChunks =
        List.splitInto 3 WebData.galleryImages

    let verticalTile galleryImages =
        Bulma.column (List.map (galleryImage onClick) galleryImages)

    Bulma.columns [
        prop.children (List.map verticalTile galleryChunks)
    ]
