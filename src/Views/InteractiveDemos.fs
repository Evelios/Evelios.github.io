module App.Views.InteractiveDemos

open Feliz
open Feliz.Bulma

open App


let private card (demo: InteractiveDemo) : ReactElement =
    let image =
        Bulma.cardImage [
            Bulma.image.isSquare
            prop.children [
                Html.img [
                    prop.alt demo.Description
                    prop.src (Image.interactive demo.Image)
                ]
                Html.img [
                    prop.className "interactive-background"
                    prop.style [
                        style.display.inlineBlock
                        style.position.absolute
                        style.top 0
                        style.left 0
                    ]
                    prop.alt demo.Description
                    prop.src (Image.interactive demo.HoverImage)
                ]
            ]
        ]

    let content =
        Bulma.cardContent [
            Bulma.media [
                Bulma.mediaContent [
                    Bulma.title.p [
                        title.is4
                        prop.text demo.Title
                    ]
                ]
            ]
            Bulma.content demo.Description
        ]

    Bulma.tile [
        tile.isParent
        tile.is3
        prop.children [
            Html.a [
                prop.href demo.Link
                prop.children [
                    Bulma.card [
                        prop.children [ image; content ]
                    ]
                ]
            ]
        ]
    ]

let view: ReactElement =
    let interactiveWorks =
        List.map card WebData.interactiveWorks

    Bulma.tile [
        tile.isAncestor
        prop.style [
            style.display.flex
            style.flexWrap.wrap
        ]
        prop.children interactiveWorks
    ]
