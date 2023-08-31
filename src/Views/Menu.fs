module App.Views.Menu

open Feliz
open Feliz.Bulma

open App
open App.Router

let private title =
    Bulma.navbarItem.a
        [ prop.href Router.home
          prop.children [ Bulma.title [ title.is4; prop.text WebData.title ] ] ]

let private navbarLink (project: Project) =
    Bulma.navbarItem.a
        [ prop.text project.Title
          prop.href project.Source
          if not <| Router.isLocalLink project.Source then
              prop.target "_blank"
              prop.rel "noopener noreferrer" ]

let private projects =
    let packages = Bulma.menuList (List.map navbarLink WebData.packages)

    let commissions = Bulma.menuList (List.map navbarLink WebData.commissions)



    Bulma.navbarItem.div
        [ navbarItem.hasDropdown
          navbarItem.isHoverable
          prop.children
              [ Bulma.navbarLink.a [ prop.text "Projects" ]
                Bulma.navbarDropdown.div [ packages; Bulma.navbarDivider []; commissions ] ] ]



let private packages =
    let packages = List.map navbarLink WebData.packages

    Bulma.navbarItem.div
        [ navbarItem.hasDropdown
          navbarItem.isHoverable
          prop.children
              [ Bulma.navbarLink.a [ prop.text "Packages" ]
                Bulma.navbarDropdown.div packages ] ]

let private commissions =
    let commissions = List.map navbarLink WebData.commissions

    Bulma.navbarItem.div
        [ navbarItem.hasDropdown
          navbarItem.isHoverable
          prop.children
              [ Bulma.navbarLink.a [ prop.text "Commissions" ]
                Bulma.navbarDropdown.div commissions ] ]

let private gallery =
    navbarLink
        { Title = "Gallery"
          Source = Router.toHash Route.Gallery }

let private demos =
    navbarLink
        { Title = "Demos"
          Source = Router.toHash Route.Demos }

let private github =
    Bulma.navbarItem.a
        [ prop.children [ Icon.github ]
          prop.href WebData.Links.github
          prop.target "_blank"
          prop.rel "noopener noreferrer" ]

let private about =
    navbarLink
        { Title = "About"
          Source = WebData.Links.about }

let private burger =
    Bulma.navbarBurger [ prop.role "button"; navbarBurger.isActive ]

let view () : ReactElement =
    Bulma.navbarMenu
        [ Bulma.navbarBrand.div [ prop.children [ title; burger ] ]
          Bulma.navbarStart.div [ packages; commissions; shop ]
          Bulma.navbarStart.div [ gallery; demos; projects ]
          Bulma.navbarEnd.div [ github; about ] ]
