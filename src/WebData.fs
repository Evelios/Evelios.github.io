module App.WebData

module Links =
    let github = "https://github.com/evelios"



/// Projects that I have worked on
let projects =
    [ { Title = "Pretty Rough Shape"
        Source = "https://prettyroughshape.com" } ]

let packages =
    [ { Title = "F# - Math.Units"
        Source = "https://www.nuget.org/packages/Math.Units" }
      { Title = "F# - Math.Geometry"
        Source = "https://www.nuget.org/packages/Math.Geometry" } ]

/// Images that are available in the gallery.
let galleryImages: GalleryImage list =
    [ { Title = "Waterfall"
        Source = "waterfall.jpg" }
      { Title = "Twist"
        Source = "twist.jpg" }
      { Title = "Birch"
        Source = "birch.jpg" }
      { Title = "Fire"
        Source = "fire-tendrils.jpg" }
      { Title = "Fission"
        Source = "fission.jpg" }
      { Title = "Glyphs"
        Source = "glyphs.jpg" }
      { Title = "Shrimp"
        Source = "shrimp.jpg" }
      { Title = "Kelp"; Source = "kelp.jpg" }
      { Title = "Venetian"
        Source = "curtains.jpg" }
      { Title = "Shades"
        Source = "shades.jpg" } ]


/// All the interactive works that available on the website.
let interactiveWorks =
    [ { Title = "Island Generator"
        Description = "Based on plate tectonics weather and erosion patterns"
        Image = "island_generator_foreground.png"
        HoverImage = "island_generator_background.png"
        Link = "https://evelios.github.io/procIsland/" }

      { Title = "Cellular Automata"
        Description = "Cellular automata using arbitrary grid patterns"
        Image = "cellular_automata_foreground.png"
        HoverImage = "cellular_automata_background.png"
        Link = "https://evelios.github.io/Atum/examples/Cellular_Automata/Cellular_Automata.html" }

      { Title = "Polygon Subdivision"
        Description = "Dividing polygons in half forever"
        Image = "polygon_subdivision_foreground.png"
        HoverImage = "polygon_subdivision_background.png"
        Link = "https://evelios.github.io/Atum/examples/Polygon_Subdivision/Polygon_Subdivision.html" }
      { Title = "Binary Space Partitioning"
        Description = "Subdividing rectangles"
        Image = "binary_space_partitioning_foreground.png"
        HoverImage = "binary_space_partitioning_background.png"
        Link = "https://evelios.github.io/Atum/examples/Binary_Space_Partition/Binary_Space_Partition.html" }

      { Title = "Recursive Voronoi Subdivision"
        Description = "Subdividing rectangles"
        Image = "recursive_voronoi_foreground.png"
        HoverImage = "recursive_voronoi_background.png"
        Link = "https://evelios.github.io/Atum/examples/Recursive_Voronoi/Recursive_Voronoi.html" }

      { Title = "Point Distributions"
        Description = "Comparing different random point distributions"
        Image = "point_distribution_foreground.png"
        HoverImage = "point_distribution_background.png"
        Link = "https://evelios.github.io/Atum/examples/Point_Distributions/Point_Distributions.html" }

      { Title = "Adaptive Poisson Sampling"
        Description = "Method for a random blue noise point distribution"
        Image = "adaptive_poisson_sampling_foreground.png"
        HoverImage = "adaptive_poisson_sampling_background.png"
        Link = "https://evelios.github.io/adaptive-poisson-sampling/example.html" } ]
