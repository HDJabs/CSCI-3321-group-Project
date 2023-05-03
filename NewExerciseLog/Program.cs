var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication("ExerciseLogCookie").AddCookie("ExerciseLogCookie", options =>
{
    options.Cookie.Name = "ExerciseLogCookie";
    options.LoginPath = "/Users/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();//could be reason for pages "OnGet()-ing" twice

app.MapRazorPages();

app.Run();
