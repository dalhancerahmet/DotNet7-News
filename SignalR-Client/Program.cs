using Microsoft.AspNetCore.SignalR.Client;

HubConnection connection = new HubConnectionBuilder()
    .WithUrl("https://localhost:7135")
    .Build();
await connection.StartAsync();
Console.WriteLine($"Bağlantı Adresiniz: {connection.ConnectionId}");

connection.On<string,string>("receiveMessage",async message =>
{
    Console.WriteLine(message);
    return "Cleint tarafından mesaj iletildi.";
});