module App.Pages.Home

open Feliz
open Feliz.Bulma

open App
open App.Responsive

let private bodySection (name: string) (content: ReactElement) : ReactElement =
    let title = Bulma.title [ title.is1; prop.text name; text.hasTextCentered ]

    Bulma.section [ title; content ]


let view (device: Device) (onSelectGalleryImage: GalleryImage -> unit) : ReactElement =
    let divider = Bulma.navbarDivider []

    let gallery =
        bodySection "Gallery Images" (Gallery.imageGallery device onSelectGalleryImage)

    let demos = bodySection "Interactive Demos" (Demos.view device)

    Html.div [ gallery; divider; demos ]
