# Practice-Luecne-Queries

Examine and Lucene notes

    - Lucene Analysers determin the rules for indexing and searching
    	- when indexing; it can leave out certain words or characters
    	- when searching; it will ignore certain words, chars, or whitespace ect.
    	- StandardAnalyzer and WhitespaceAnalyzer are two very popular analyzers

    - Luke is dev and debug tool for working with Lucene indexes like Examine

    - 2 ways to do querys for Lucene and Indexes
    	- Fluent API
    	- Raw Lucene Queries

   	- Fluent API
   		- Query chainning API
   		- first specify search provider and save to var


    - Lucene Query         |------------------------
    	Ex: nodeName:hello   metaTitle:hello        |
    												|
        select Any node with the nodeName of hello OR metaTitle of hello
