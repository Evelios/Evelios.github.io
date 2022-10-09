module App.Cards

open Elmish
open Elmish.React
open Feliz
open Feliz.Bulma


let card: ReactElement =
    let image =
        Bulma.cardImage [
            Bulma.image [
                prop.children [
                    Html.img [
                        prop.alt "Placeholder image"
                        prop.src "https://bulma.io/images/placeholders/1280x960.png"
                    ]
                ]
            ]
        ]

    let content =
        Bulma.cardContent [
            Bulma.media [
                Bulma.mediaContent [
                    Bulma.title.p [
                        Bulma.title.is4
                        prop.text "Feliz Bulma"
                    ]
                ]
            ]
            Bulma.content "Lorem ipsum dolor sit ... nec iaculis mauris."
        ]

    Bulma.tile [
        tile.is3
        tile.isParent
        prop.children [
            Bulma.card [
                prop.children [ image; content ]
            ]
        ]
    ]

let view: ReactElement =
    let cards = List.replicate 10 card

    Bulma.tile [
        tile.isAncestor
        prop.style [
            style.display.flex
            style.flexWrap.wrap
        ]
        prop.children cards
    ]
