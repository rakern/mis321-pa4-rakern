#PA4:
Connects my database created in PA3 to a front-end website

Big Al Goes Full Stack!
  In PA1 we created the back end of the Big Al’s Playlist system.
  In PA3 we connected the Big Al’s Playlist system to a MySQL
  database.
  In this project we want to update that application to connect
  our front-end web application to the back in application we
  have built. This means you will need to create a new webapi
  app for the front end to call. You can port your back-end
  classes over to the new webapi app.
  
Available Functions
  Within the menu of the application the user should be able to:
  1. Show all songs – No need to show ID or Timestamp on a web UI
  2. Add a song
  3. Delete a song
  4. Favorite a song
  * All songs should display in descending timestamp order.
  *** Whenever a change is made, the database must be updated to
  reflect the change
  
Tracking Posts
  • Big Al’s songs should be read in from a MySQL database.
  The table should be the songs table. The table should have
  the following fields:
  • Id
  • Title
  • Date Added
  • Deleted
  • Favorited
  • The Id can be an auto incremented integer or a UUID string.
  
Database Design
  • Your design should plan for the future. We may even
  move to a 3-tier architecture at some point and move
  crud operations out of the base app.
  •i.e. this requirement is to use the strategy pattern!
