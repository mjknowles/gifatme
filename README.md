##Summary of the Gif At Me Project

This project began after my coworkers and I decided we needed an easy way to store and recall reaction .gif files from Slack. GifAtMe is essentially an API to a backend database that allows users to store personalizeds link to a .gif file as well as an associated keyword. This allows our Slack chatbot to reach out to the API when a user requests a gif with a certain keyword. There's also an MVC component that allows users to view all the gifs they have uploaded in the past. Edit and delete functionality is still pending.

For example, in Slack chat, a user my type "gifatme highfive". The Slack chatbot will reach out to this API and pull the "highfive" gif URL uploaded by the requestor.

This project is also for my own personal learning benefit. I've used it to experiment with Angular on the front end and establish a repeatable architecture on the backend.

The application is divided into five main layers (starting from outermost facing):
1. Repository layer - data access logic
2. Domain layer - used to encapsulate business rules/logic of the application's entities
3. Service layer - defines the "internal application" barrier of GifAtMe
4. UI layer - WebAPI/MVC layer for presenting the user with either the data or web page they need
5. Common - common code utilized across all projects
