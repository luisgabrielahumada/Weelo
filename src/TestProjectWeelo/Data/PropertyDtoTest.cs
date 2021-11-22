﻿using System;
using System.Collections.Generic;
using Weelo.Dto.Auth;
using Weelo.Dto.Common;
using Weelo.Dto.Property;

namespace TestProjectWeelo.Helper
{
    public static class PropertyDtoTest
    {
        public static List<PropertyAllDto> Properties()
        {
            return new List<PropertyAllDto>
            {
                new PropertyAllDto
                {
                    IdProperty =2,
                    Name="Caiba 50",
                    Address="Parque Residencial Prado Verde Sector Ceiba",
                    Price=32000000,
                    CodeInternational="00001",
                    Year=2020,
                    IdOwner=1,
                    AddressOwner="Envigado Calle 38b Sur #26-02 apto 1824 Torre 3",
                    Birthday="9/13/1980",
                    NameOwner="Luis Gabriel Ahumada",
                    Photo ="https://weelo.blob.core.windows.net/attachments/a3170ad3-f88f-4426-9b2e-fcc67786f361-profile.png",
                    TotalRecords=8
                },
                new PropertyAllDto
                {
                    IdProperty =3,
                    Name="Caiba 50",
                    Address="Parque Residencial Prado Verde Sector Ceiba",
                    Price=87000,
                    CodeInternational="00005",
                    Year=2020,
                    IdOwner=1,
                    AddressOwner="Envigado Calle 38b Sur #26-02 apto 1824 Torre 3",
                    Birthday="9/13/1980",
                    NameOwner="Luis Gabriel Ahumada",
                    Photo ="https://weelo.blob.core.windows.net/attachments/c0155813-1683-4b66-82f9-398807c0fa89-Luis%20Gabriel%20Ahumada",
                    TotalRecords=8
                },
                new PropertyAllDto
                {
                    IdProperty =5,
                    Name="Caiba 2",
                    Address="Parque Residencial Prado Verde Sector Ceiba",
                    Price=32000000,
                    CodeInternational="00005",
                    Year=2020,
                    IdOwner=1,
                    AddressOwner="Envigado Calle 38b Sur #26-02 apto 1824 Torre 3",
                    Birthday="9/13/1980",
                    NameOwner="Luis Gabriel Ahumada",
                    Photo ="https://weelo.blob.core.windows.net/attachments/c0155813-1683-4b66-82f9-398807c0fa89-Luis%20Gabriel%20Ahumada",
                    TotalRecords=8
                },
                new PropertyAllDto
                {
                    IdProperty =6,
                    Name="Caiba 2",
                    Address="Parque Residencial Prado Verde Sector Ceiba",
                    Price=32000000,
                    CodeInternational="00001",
                    Year=2020,
                    IdOwner=1,
                    AddressOwner="Envigado Calle 38b Sur #26-02 apto 1824 Torre 3",
                    Birthday="9/13/1980",
                    NameOwner="Luis Gabriel Ahumada",
                    Photo ="https://weelo.blob.core.windows.net/attachments/a3170ad3-f88f-4426-9b2e-fcc67786f361-profile.png",
                    TotalRecords=8
                },
                 new PropertyAllDto
                {
                    IdProperty =7,
                    Name="Caiba 22",
                    Address="Parque Residencial Prado Verde Sector Ceiba",
                    Price=32000000,
                    CodeInternational="00001",
                    Year=2020,
                    IdOwner=1,
                    AddressOwner="Envigado Calle 38b Sur #26-02 apto 1824 Torre 3",
                    Birthday="9/13/1980",
                    NameOwner="Luis Gabriel Ahumada",
                    Photo ="https://weelo.blob.core.windows.net/attachments/a3170ad3-f88f-4426-9b2e-fcc67786f361-profile.png",
                    TotalRecords=8
                },
            };
        }

        public static NewPropertyDto NewProperty()
        {
            return new NewPropertyDto
            {
                Name = "Caiba XX",
                Address = "Parque Residencial Prado Verde Sector Ceiba",
                Price = 836493,
                CodeInternational = "00001",
                Year = 2010,
                IdOwner = 1,
                PropertyTrace = new List<PropertyTraceDto>()
                 {
                      new PropertyTraceDto
                      {
                        DateSale =DateTime.Now,
                        Name="Adminsitración",
                        Tax=0,
                        Value=290000
                      },
                      new PropertyTraceDto
                      {
                        DateSale =DateTime.Now,
                        Name="Cannon",
                        Tax=0,
                        Value=1500000
                      }
                 }

            };
        }

        public static PropertyDto Property()
        {
            return new PropertyDto
            {
                Name = "Caiba XX",
                Address = "Parque Residencial Prado Verde Sector Ceiba",
                Price = 836493,
                CodeInternational = "00001",
                Year = 2010,
                IdOwner = 1
            };
        }

        public static PropertyPriceDto PropertyPrice()
        {
            return new PropertyPriceDto
            {
                Price = 90000
            };
        }

        public static PropertyImageDto NewImage()
        {
            return new PropertyImageDto
            {
                Enabled = true,
                File = new FileDto
                {
                    Name = "prueba.jpg",
                    Content = "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"
                }
            };
        }

        public static PropertyImageDto NewNotContentImage()
        {
            return new PropertyImageDto
            {
                Enabled = true,
                File = new FileDto
                {
                    Name = "prueba.jpg",
                    Content = string.Empty
                }
            };
        }
    }
}
