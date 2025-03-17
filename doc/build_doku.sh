pandoc --number-sections -V lang=de-CH \
  --pdf-engine=xelatex \
  -M link-citations=true \
  --toc --toc-depth=2 --lof \
  --template eisvogel.latex --shift-heading-level-by=-1 \
  --out Projekt_Wissensmanagement.pdf \
  -V titlepage=true \
  Dokumentation.md meta.yaml
