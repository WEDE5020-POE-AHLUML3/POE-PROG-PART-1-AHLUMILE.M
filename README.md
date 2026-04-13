# POE-PROG-PART-1-AHLUMILE.M
<img width="1253" height="614" alt="image" src="https://github.com/user-attachments/assets/84666b2a-fb96-4335-9a67-02df46ddc36d" />


Got you — here is a clean README for your **GitHub workflow (CI build)** written in the same simple professional style.

You can paste this into your repository:

---

# GitHub Actions CI Build

## Overview

This project uses GitHub Actions to automatically build and test the C# console application whenever changes are pushed to the repository.

The workflow ensures that the project builds correctly on every update and helps maintain code stability.

---

## Workflow Purpose

The GitHub Actions pipeline is used to:

* Automatically restore dependencies
* Build the project on push and pull request
* Ensure the code compiles without errors
* Run tests (if available in the project)

---

## Workflow File

The workflow is located at:

```
.github/workflows/dotnet-desktop.yml
```

---

## Trigger Events

The workflow runs automatically when:

* Code is pushed to the `main` branch
* A pull request is created targeting the `main` branch

---

## Build Environment

* Operating System: Windows Latest
* .NET Version: 8.0
* Configuration: Debug and Release

---

## Build Steps

The workflow performs the following steps:

1. Checkout repository code
2. Install .NET SDK
3. Restore project dependencies
4. Build the project in Release and Debug mode
5. Run tests (if available)

---

## Project Type

This workflow is designed for a:

* C# Console Application
* .NET 8.0 project

It does NOT use:

* WPF
* Windows Packaging (MSIX)
* Signing certificates

---

## Purpose of CI Pipeline

The CI pipeline ensures:

* Code compiles successfully after every change
* Errors are detected early
* Project remains stable during development

---

## Status

If the workflow shows a green checkmark, it means:

* The project built successfully
* No compilation errors were found

