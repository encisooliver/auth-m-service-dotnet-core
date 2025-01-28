using auth_project.DTOs;

namespace auth_project.Endpoints;
public static class UserEndpoints
{
    const string GetUserEndpointName = "GetUser";

    private static readonly List<UserDTO> users = [
        new (
            1,
            "Blitz One",
            "fblitz",
            "fblitz1@gmail.com"
        ),
        new (
            2,
            "Blitz Two",
            "fblitz2",
            "fblitz2@gmail.com"
        ),
        new (
            3,
            "Blitz Three",
            "fblitz3",
            "fblitz3@gmail.com"
        )
    ];

    public static RouteGroupBuilder MapUserEndpoints(this WebApplication app){
        
        var group = app.MapGroup("users").WithParameterValidation();
        // Get /users
        group.MapGet("/", () => users);

        // Get /users/1
        group.MapGet("/{id}", (int id) => {
            UserDTO? user = users.Find(game => game.Id == id);

            return user != null ? Results.Ok(user) : Results.NotFound();
        }).WithName(GetUserEndpointName);

        // POST /users
        group.MapPost("/", (CreateUserDTO newUser) => 
        {
            UserDTO user = new (
                users.Count + 1,
                newUser.Name,
                newUser.UserName,
                newUser.Email
            );

            users.Add(user);

            return Results.CreatedAtRoute(GetUserEndpointName, new {id = user.Id}, user);
        });

        // PUT /users
        group.MapPut("/{id}", (int id, UpdateUserDTO updateUser)=>{
            var userIndex = users.FindIndex(user => user.Id == id); 
            users[userIndex] = new UserDTO(
                id,
                updateUser.Name,
                updateUser.UserName,
                updateUser.Email
            );

            return Results.NoContent();
        });

        // Delete /users
        group.MapDelete("/{id}",(int id)=>{
            users.RemoveAll(user => user.Id == id);
            return Results.NoContent();
        });

        return group;
    }
    
}
