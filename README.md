
API access
Expose an API allowing external systems to manage bookmarks.  You will need to consider authentication / access tokens
        
  CRUD calls (Create, Edit, Get and Delete) from both Bookmark and Category controller should be moved from the current WebApp project to a new WebAPI project in order to isolate the business logic and the UI. In order to have the same authentication mechanisms (on both WebApp and WebAPI), the same user's db can be used for authentication in both projects. A better approach would be to isolate the user-related tables from the db into a separate db, used by a new project that would only deal with the authentication.
    
Tracking and reporting
Track each time a user clicks out on one of their saved bookmarks and provide a simple dashboard which can show a summary of stats by user, and as an overview (e.g. for tracking the most popular links).
        Users should also be able to share a short url with their friends which when clicked would also log usage statictics and be reported on
        
  For each bookmark, we should keep usage data. We could introduce a new table (Click) that would keep info about each click on a bookmark. Initially, the columns of that table would keep info about BookmarkId, DateClicked, CreatorId, ClickerId (nullable, as it can be clicked anonymously).
        Each click on a bookmark should go through a proxy endpoint which should look like this: api/click/{bookmarkId}. This proxy endpoint is basically the "short url".
    
Website widget
Provide 1 or more widgets that can be used in an external website, regardless of the server side technology.  These can provide any functionality you choose - for example showing the most recent 5 bookmarks for a particular user, or the 3 most popular bookmarks today
        
  If the previously mentioned Click table and the related proxy endpoint are implemented, this widget would be just a result of a query that would search for the most popular links for the previous 24h. The widget can be rendered by any popular js framework that would be found suitable for the need.
