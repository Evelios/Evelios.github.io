module App.Image

/// Get the source of the image given it's root name
let toHref (image: Image): string =
    "/img/" + image
    
let interactive (image: Image): string =
    "/img/interactive/" + image
