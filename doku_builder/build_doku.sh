cd ../docs

pandoc --number-sections -V lang=de-CH \
  --pdf-engine=xelatex \
  --bibliography "../docs/quellen.bib" \
  --citeproc --csl="../doku_builder/din-1502.csl" \
  -M link-citations=true \
  --toc --toc-depth=2 --lof \
  --lua-filter ../doku_builder/diagram-filter.lua \
  --lua-filter ../doku_builder/include-files.lua \
  --template ../doku_builder/eisvogel.latex --shift-heading-level-by=-1 \
  --out ../doku_builder/Projekt_Ausleihbar.pdf \
  -V titlepage=true \
  Dokumentation.md ../doku_builder/meta.yaml
