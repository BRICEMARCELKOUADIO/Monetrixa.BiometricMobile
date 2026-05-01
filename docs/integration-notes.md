
### `docs/integration-notes.md`

```markdown
# Notes d’intégration

## Objectif

Ce document suit les décisions et contraintes techniques rencontrées pendant l’intégration des SDK biométriques.

## Face ID

Points identifiés :

- SDK fourni sous forme de `.aar`.
- Intégration .NET MAUI non directe.
- Un projet Android Binding sera nécessaire.
- La démo Android utilise Java et Gradle.
- Le projet initial nécessitait un ajustement Gradle/AGP pour fonctionner dans Android Studio récent.

## Fingerprint

À compléter.

## Points de vigilance

- Licence SDK.
- Compatibilité Android.
- Permissions caméra.
- Permissions liées au matériel fingerprint.
- Stockage sécurisé des templates biométriques.
- Chiffrement.
- Suppression des données biométriques.

## Validation architecture MAUI

La première version de l’application MAUI a été lancée avec succès.

Les tests mock suivants fonctionnent :

- Enrôlement Face ID
- Enrôlement Fingerprint
- Enrôlement Face ID + Fingerprint

Cette étape valide la structure App / Application / Domain / Infrastructure ainsi que l’orchestration biométrique via `IBiometricOrchestrator`.