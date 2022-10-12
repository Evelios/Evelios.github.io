module App.Views.Gallery

open Feliz
open Feliz.Bulma

open App

let private galleryImage (onClick: GalleryImage -> unit) (img: GalleryImage) =
    Bulma.box [
        prop.onClick (fun _ -> onClick img)
        prop.className "gallery"
        prop.style [
            style.padding 0
            style.width.unset
        ]
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

let view (browserSize: Responsive.Device) (onClick: GalleryImage -> unit) =
    let columns =
        match browserSize with
        | Responsive.Mobile -> 1
        | Responsive.Tablet -> 2
        | Responsive.Desktop -> 3
        
    FloatingGrid.inColumns columns (List.map (galleryImage onClick) WebData.galleryImages)
