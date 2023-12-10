module App.Pages.Home

open Feliz
open Feliz.Bulma

open App
open App.Components
open App.Responsive
open App.Router

let roundedImage (image: Image) (alt: string) =
    Bulma.box
        [ prop.style [ style.padding 0; style.width.unset ]
          prop.children
              [ Bulma.cardImage
                    [ Bulma.image
                          [ Html.img
                                [ prop.style [ style.cursor.pointer ]
                                  prop.alt alt
                                  prop.src (Router.Image.homepage image) ] ] ] ] ]

/// The first hero section that appears on the homepage. This is the first
/// information that the user will see when coming to the website.
let primaryHero =
    let shopName = "Calm Waters Design"
    let artistDescription = "Artist, Engineer, Maker"

    let penPlotterImage =
        roundedImage "Simon Farussell - Noise Flower.jpg" "Pen Plotter Drawing My Artwork"

    let shopButton = Bulma.button.a [ prop.text shopName; prop.href WebData.Links.shop ]

    // Column Components
    let leftColumn = Bulma.column [ penPlotterImage ]

    let rightColumn =
        Bulma.column [ prop.children [ Bulma.title artistDescription; shopButton ] ]

    Bulma.hero
        [ Bulma.color.isPrimary
          prop.children [ Bulma.heroBody [ Bulma.columns [ leftColumn; rightColumn ] ] ] ]

let view (device: Device) (onSelectGalleryImage: GalleryImage -> unit) : ReactElement =
    let divider = Bulma.navbarDivider []

    let gallery =
        Body.section "Gallery Images" (Gallery.imageGallery device onSelectGalleryImage)

    let demos = Body.section "Interactive Demos" (Demos.demoGrid device)

    Html.div [ primaryHero; gallery; divider; demos ]
