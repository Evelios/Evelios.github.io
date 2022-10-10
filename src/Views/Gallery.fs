module App.Views.Gallery

open Fable.React.Props
open Feliz
open Feliz.Bulma

open App


let galleryImage (gallery: GalleryImage) =
    let image =
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

    Bulma.tile [
        tile.isParent
        tile.is4
        prop.children [
            Bulma.tile [
                tile.isChild
                prop.children [ image ]
            ]
        ]
    ]


let view =
    let galleryImages =
        List.map galleryImage WebData.galleryImages

    Bulma.tile [
        tile.isAncestor
        prop.style [
            style.display.flex
            style.flexWrap.wrap
        ]
        prop.children galleryImages
    ]
