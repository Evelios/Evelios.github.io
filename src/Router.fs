namespace App.Router

type Route = | Home

module Router =
    
    open App

    open Elmish
    open Elmish.Navigation


    let inline (</>) a b = a + "/" + string b

    let home = "/"

    module Image =
        let interactive (image: Image) : string = "/img/interactive/" + image

        let gallery (image: Image) : string = "/img/gallery/" + image


    let toHash route =
        "/#"
        </> match route with
            | Home -> ""

    let navigateTo routeOpt =
        match routeOpt with
        | Some route -> Navigation.modifyUrl (toHash route)
        | None -> Cmd.none

    open Elmish.UrlParser

    let routeParser: Parser<Route -> Route, Route> = oneOf [ map Home top ]

    let mapCharacters (s: string) = s.Replace("%20", " ")
