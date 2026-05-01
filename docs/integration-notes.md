
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