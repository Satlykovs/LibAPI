using LibAPI;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddSingleton<ILibManager>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<LibContext>();
    optionsBuilder.UseSqlite("Data Source=LibDataBase.db");
    var libContext = new LibContext(optionsBuilder.Options);
    libContext.Database.EnsureCreated();
    IBookRepository bookRepository = new BookRepository(libContext);
    IUserLibraryRepository userLibraryRepository = new UserLibraryRepository(libContext);
    IExchangeRepository exchangeRepository = new ExchangeRepository(libContext);
    ILibManager libManager = new LibManager(bookRepository, userLibraryRepository, exchangeRepository);

    return libManager;

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
