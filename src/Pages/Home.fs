module App.Pages.Home

open Feliz
open Feliz.Bulma

open App
open App.Components
open App.Responsive

let view (device: Device) (onSelectGalleryImage: GalleryImage -> unit) : ReactElement =
    let divider = Bulma.navbarDivider []

    let gallery =
        Body.section "Gallery Images" (Gallery.imageGallery device onSelectGalleryImage)

    let demos = Body.section "Interactive Demos" (Demos.demoGrid device)

    Html.div [ gallery; divider; demos ]
