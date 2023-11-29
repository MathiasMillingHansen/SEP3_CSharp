// See https://aka.ms/new-console-template for more information

using EFC_DataAccess;

DatabaseContext context = new();
DatabaseInitializer.Initialize(context);