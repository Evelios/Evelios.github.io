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

let view: ReactElement =
    let navbarLink (project: Project) =
        Bulma.navbarItem.a [
            prop.text project.Title
            prop.href project.Source
            prop.target "_blank"
            prop.rel "noopener noreferrer"
        ]

    let projects =
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
        
    let packages =
        let projects =
            List.map navbarLink WebData.packages

        Bulma.navbarItem.div [
            navbarItem.hasDropdown
            navbarItem.isHoverable
            prop.children [
                Bulma.navbarLink.a [
                    prop.text "Packages"
                ]
                Bulma.navbarDropdown.div projects
            ]
        ]

    let github =
        Bulma.navbarItem.a [
            prop.children [
                Icon.github
            ]
            prop.href WebData.Links.github
            prop.target "_blank"
            prop.rel "noopener noreferrer"
        ]

    Bulma.navbarMenu [
        Bulma.color.isPrimary
        prop.children [
            Bulma.navbarStart.div [
                title
                projects
                packages
            ]
            Bulma.navbarEnd.div [ github ]
        ]
    ]
