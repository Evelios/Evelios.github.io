module App.Views.Gallery

open Feliz
open Feliz.Bulma

open App


let galleryImage (gallery: GalleryImage) =
    Bulma.box [
        prop.style [ style.padding 0 ]
        prop.children [
            Bulma.cardImage [
                Bulma.image [
                    Html.img [
                        prop.src (Route.Image.gallery gallery.Source)
                    ]
                ]
            ]
        ]
    ]



let view =
    let galleryChunks =
        List.splitInto 3 WebData.galleryImages

    let verticalTile galleryImages =
        Bulma.column (List.map galleryImage galleryImages)

    Bulma.columns [
        prop.children (List.map verticalTile galleryChunks)
    ]
