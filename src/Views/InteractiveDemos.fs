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
                    prop.src (Route.Image.interactive demo.Image)
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
                    prop.src (Route.Image.interactive demo.HoverImage)
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

    Html.a [
        prop.href demo.Link
        prop.target "_blank"
        prop.rel "noopener noreferrer"
        prop.children [
            Bulma.card [
                prop.style [
                    style.maxWidth 500
                    style.margin.auto
                ]
                prop.children [ image; content ]
            ]
        ]
    ]

let view (browserSize: Responsive.Device) : ReactElement =
    let columns =
        match browserSize with
        | Responsive.Mobile -> 1
        | Responsive.Tablet -> 3
        | Responsive.Desktop -> 4

    FloatingGrid.inGrid columns (List.map card WebData.interactiveWorks)
