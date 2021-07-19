<h1>Read Later</h1>
<h2>A revolution in the world of social bookmarking</h2>
Read Later is a fictional service designed to test a range of skills using the .net core 5 MVC architecture. For full details about this project, the libraries used, and a quickstart guide to getting it up and running, please visit the About page

<h3>Tasks</h3>
<p>
    The following 2 functionalities have been completed:
</p>
<ol>
    <li>
        <h5>Bookmark management</h5>
        Implement full CRUD management for Bookmarks.  Users should be able to create a new category whilst creating a bookmark without requiring any page refresh
    </li>
    <li>
        <h5>User accounts</h5>
        The package has the default AspNetCore Identity installed however not implemented fully.  Complete this implementation and change the entities to work on a per user basis.  For additional credit,
        implement multiple membership providers allowing users to log in with OpenID services
    </li>
</ol>
<h4>Remaining functionalities:</h4>
<ol>
    <li>
        <h5>API access</h5>
        Expose an API allowing external systems to manage bookmarks.  You will need to consider authentication / access tokens
    </li>
    <li>
        <h5>Tracking and reporting</h5>
        Track each time a user clicks out on one of their saved bookmarks and provide a simple dashboard which can show a summary of stats by user, and as an overview (e.g. for tracking the most popular links).
        Users should also be able to share a short url with their friends which when clicked would also log usage statictics and be reported on
    </li>
    <li class="three">
        <h5>Website widget</h5>
        Provide 1 or more widgets that can be used in an external website, regardless of the server side technology.  These can provide any functionality you choose - for example showing the most recent 5 bookmarks for a particular user, or the 3 most popular bookmarks today
    </li>
</ol>
