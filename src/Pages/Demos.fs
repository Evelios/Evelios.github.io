/// View all the interactive demos that I have created.
module App.Pages.Demos

open App
open App.Router
open App.Components

open Feliz
open Feliz.Bulma
open Fable.React


/// A single demo card that includes a picture transition of the demo and a
/// description of what that demo is.
let private card (demo: InteractiveDemo) : ReactElement =
    let image =
        Bulma.cardImage
            [ Bulma.image.isSquare
              prop.children
                  [ Html.img [ prop.alt demo.Description; prop.src (Router.Image.interactive demo.Image) ]
                    Html.img
                        [ prop.className "interactive-background"
                          prop.style
                              [ style.display.inlineBlock
                                style.position.absolute
                                style.top 0
                                style.left 0 ]
                          prop.alt demo.Description
                          prop.src (Router.Image.interactive demo.HoverImage) ] ] ]

    let content =
        Bulma.cardContent
            [ Bulma.media [ Bulma.mediaContent [ Bulma.title.p [ title.is4; prop.text demo.Title ] ] ]
              Bulma.content demo.Description ]

    Html.a
        [ prop.href demo.Link
          prop.target "_blank"
          prop.rel "noopener noreferrer"
          prop.children
              [ Bulma.card
                    [ prop.style [ style.maxWidth 500; style.margin.auto ]
                      prop.children [ image; content ] ] ] ]

/// A view of all the demos that have been created. This is a grid layout
/// organizing the demos to be viewed.
let demoGrid (device: Responsive.Device) : ReactElement =
    let columns =
        match device with
        | Responsive.Mobile -> 1
        | Responsive.Tablet -> 3
        | Responsive.Desktop -> 4

    FloatingGrid.inGrid columns (List.map card WebData.interactiveWorks)

/// The interactive demos web page.
let view (device: Responsive.Device) : ReactElement =
    Body.section "Interactive Demos" (demoGrid device)
