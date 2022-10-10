namespace App

type Image = string
type Url = string

type InteractiveDemo =
    { Title: string
      Description: string
      Image: Image
      HoverImage: Image
      Link: Url }

type GalleryImage =
    { Title: string
      Description: string
      Source: Url }

type Project = { Title: string; Source: Url }
