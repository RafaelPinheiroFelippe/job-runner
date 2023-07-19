import os
import subprocess

# Get the list of all files tracked by git
git_files = subprocess.check_output(['git', 'ls-files']).decode().splitlines()

# Initialize the tree
tree = {}

# Populate the tree
for file_path in git_files:
    parts = file_path.split('/')
    node = tree
    for part in parts:
        node = node.setdefault(part, {})

# Function to print the tree
def print_tree(tree, prefix=""):
    keys = sorted(tree.keys())
    for key in keys:
        print(f"{prefix}- {key}")
        print_tree(tree[key], prefix + "   ")

# Print the tree
print_tree(tree)
