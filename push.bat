@echo off
echo Pushing to GitHub...
git push origin main
if %errorlevel% == 0 (
    echo Successfully pushed to GitHub!
) else (
    echo Failed to push. Check your connection and try again.
)
pause
