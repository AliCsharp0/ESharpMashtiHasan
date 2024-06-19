var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();//in ja har kas ke be class mvc niaz dare barash iek object saghte
var str = builder.Configuration["ShoppingConnectionString"];
Shopping.BootStrap.ShoppingBootStraper.WireUp(builder.Services, str);//in haman IOC hastesh

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();// in ja mige ager request to lazeme bood  ke taghir kone be to ejaze vorod be charkhe mvc ro nmideh

app.UseStaticFiles();//in ja mige ke agar file to css ia js bood niazi nist ke to vard charkhe mvc bshi caret ro to wwwroot rah mindaze

app.UseRouting();

app.UseAuthorization();// in ja mige ke aslan in request ke to zadi hagh dast resi be mvc ro dare ia na

app.MapControllerRoute(//in ja mige ke bia system rotinget ro  confing con  ,,, in ja miad request ke shoma zadid ro mifreste be flan controller va flan action
    name: "default",//in ja mige ke baad az inke system rotinget ro config kardi iek rot be esm default misaze 
    pattern: "{controller=Home}/{action=Index}/{id?}");// in ja mige ke har rikoes moteshakel mishe az che controllery che actiony va che idy gharare call beshe

app.Run();
