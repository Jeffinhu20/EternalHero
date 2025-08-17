# CI Android (Unity) via GitHub Actions

1) Repo no GitHub com este projeto.
2) Crie secrets em *Settings → Secrets → Actions*:
   - `UNITY_LICENSE` (conteúdo do .ulf)
   - (opcional p/ assinatura) `ANDROID_KEYSTORE_BASE64`, `ANDROID_KEYSTORE_PASS`, `ANDROID_KEYALIAS_NAME`, `ANDROID_KEYALIAS_PASS`
3) Vá em **Actions → Android Build (Unity) → Run workflow**.
4) Baixe o artefato (.aab). Para **APK**:
   - Edite `.github/workflows/unity-android.yml` e troque `buildMethod: BuildAndroid.BuildAAB` por `BuildAndroid.BuildAPK`
   - No passo **Upload Artifact**, troque `*.aab` por `*.apk`

Pronto! 🚀
