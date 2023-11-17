using EcommerceWebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EcommerceWebAPI.Services;

public class ProductsService
{
    private readonly IMongoCollection<Products> _productsCollection;

    public ProductsService(
        IOptions<EcommerceDatabaseSettings> EcommerceDatabaseSettings)
    {
        var mongoClient = new MongoClient(
        EcommerceDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            EcommerceDatabaseSettings.Value.DatabaseName);

        _productsCollection = mongoDatabase.GetCollection<Products>(
            EcommerceDatabaseSettings.Value.ProductsCollectionName);
    }

    public async Task<List<Products>> GetAsync() =>
        await _productsCollection.Find(_ => true).ToListAsync();

    public async Task<Products?> GetAsync(string id) =>
        await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Products newProducts) =>
        await _productsCollection.InsertOneAsync(newProducts);

    public async Task UpdateAsync(string id, Products updatedProducts) =>
        await _productsCollection.ReplaceOneAsync(x => x.Id == id, updatedProducts);

    public async Task RemoveAsync(string id) =>
        await _productsCollection.DeleteOneAsync(x => x.Id == id);
}