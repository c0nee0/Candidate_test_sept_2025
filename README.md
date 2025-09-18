# Projekat: .NET Solution sa ASP.NET Core Web API i Windows Forms Frontendom

Ovaj projekat je .NET Framework solution koji sadrži dva projekta:

1. **Back-end (API)**: ASP.NET Core Web API
2. **Front-end (Windows Forms)**: Windows Forms aplikacija koja koristi API

## Tehnologije

- .NET Framework (9.0)
- ASP.NET Core Web API
- Windows Forms (.NET Framework)
- C#
- Visual Studio (2022)

## Funkcionalnosti

- API pruža REST endpoint-e za rad sa podacima.
- Windows Forms aplikacija komunicira sa API-jem i prikazuje podatke korisniku.
- Pokretanje oba projekta je sinhronizovano: prvo se startuje API, pa Front-end.

## Pokretanje Projekta

1. Otvorite solution u Visual Studio-u.
2. Postavite **Startup Project** na `Multiple startup projects` i odaberite:
   - `ApiProject` -> Start
   - `WinFormsProject` -> Start
3. Pokrenite solution (`F5` ili `Ctrl + F5`).  
   API će prvo biti pokrenut, a zatim Front-end aplikacija će se povezati na njega.

## Konfiguracija

- URL i port za API se može podesiti u `http://localhost:5152/` u API projektu.
- Windows Forms aplikacija koristi `ApiService` ili sličan servis za komunikaciju sa API-jem. Potrebno je da URL u `ApiService` odgovara URL-u API-ja.

## Baza Podataka

- Projekat koristi **Microsoft SQL Server** za čuvanje podataka.
- Connection string se nalazi u `appsettings.json` u API projektu:
```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=NEMANJAPC\\SQLEXPRESS;Initial Catalog=ProductsDB;Integrated Security=True;Trust Server Certificate=True"
}
```

## Autor

Nemanja Jovanović
