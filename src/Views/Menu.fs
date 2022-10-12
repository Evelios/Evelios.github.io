module App.Views.Menu

open Feliz
open Feliz.Bulma

open App

let private title =
    Bulma.navbarItem.a [
        prop.href Route.home
        prop.children [
            Bulma.title [
                title.is6
                prop.text "Thomas G. Waters"
            ]
        ]
    ]

let private navbarLink (project: Project) =
    Bulma.navbarItem.a [
        prop.text project.Title
        prop.href project.Source
        prop.target "_blank"
        prop.rel "noopener noreferrer"
    ]

let private projects =
    let projects =
        List.map navbarLink WebData.projects

    Bulma.navbarItem.div [
        navbarItem.hasDropdown
        navbarItem.isHoverable
        prop.children [
            Bulma.navbarLink.a [
                prop.text "Projects"
            ]
            Bulma.navbarDropdown.div projects
        ]
    ]

let private packages =
    let packages =
        List.map navbarLink WebData.packages

    Bulma.navbarItem.div [
        navbarItem.hasDropdown
        navbarItem.isHoverable
        prop.children [
            Bulma.navbarLink.a [
                prop.text "Packages"
            ]
            Bulma.navbarDropdown.div packages
        ]
    ]

let private github =
    Bulma.navbarItem.a [
        prop.children [ Icon.github ]
        prop.href WebData.Links.github
        prop.target "_blank"
        prop.rel "noopener noreferrer"
    ]

let private about =
    Bulma.navbarItem.a [
        prop.text "About"
        prop.href WebData.Links.about
        prop.target "_blank"
        prop.rel "noopener noreferrer"
    ]
    
let private burger =
    Bulma.navbarBurger [
        prop.role "button"
        navbarBurger.isActive
    ]

let view (): ReactElement =
    Bulma.navbarMenu [
            Bulma.navbarBrand.div [
                prop.children [
                    title
                    burger
                ]
            ]
            Bulma.navbarStart.div [
                projects
                packages
            ]
            Bulma.navbarEnd.div [ github; about ]
    ]