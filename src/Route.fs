module App.Route

let home = "/"

module Image =
    let interactive (image: Image): string =
        "/img/interactive/" + image
        
    let gallery (image: Image): string =
        "/img/gallery/" + image
