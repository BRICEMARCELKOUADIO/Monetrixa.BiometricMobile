@'
# Architecture mobile — Monetrixa BiometricMobile

## Objectif

Cette solution mobile a pour objectif de gérer l’enrôlement et la vérification biométrique des clients à travers deux moyens biométriques :

- Face ID
- Fingerprint

Le projet est structuré en plusieurs couches afin de séparer l’interface, le métier, les cas d’usage, l’infrastructure et les SDK natifs.

## Structure de la solution

```text
Monetrixa.BiometricMobile
├── src
│   ├── Monetrixa.BiometricMobile.App
│   ├── Monetrixa.BiometricMobile.Domain
│   ├── Monetrixa.BiometricMobile.Application
│   ├── Monetrixa.BiometricMobile.Infrastructure
│   ├── Monetrixa.BiometricMobile.FaceSdk.Binding
│   └── Monetrixa.BiometricMobile.FingerprintSdk.Binding
├── tests
│   └── Monetrixa.BiometricMobile.Tests
└── docs