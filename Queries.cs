var Searcher = ExamineManager.Instance.SearchProviderCollection["ExternalSearcher"];

var searchCriteria = Searcher.CreateSearchCriteria();

// using BooleanOperation.Or makes first term of a Fluent produced Lucene query a should instead of a must. Use most of time
 
 var query = searchCriteria.Field("nodeName", "hello").Or().Field("metaTitle", "hello").Compile();
// Lucene query produced =     +nodeName:hello metaTitle:hello
 							   ^----|
// Select all nodes where nodeName Must contain "hello" or metaTitle should contain "hello"
var searchResults = Searcher.Search(query);

-----------------------------------------------------

//with searchCriteria using BooleanOperation.Or 
var searchCriteria = Searcher.CreateSearchCriteria(BooleanOperation.Or);
var query = searchCriteria.Field("nodeName", "hello").Or().Field("metaTitle", "hello").Compile();
// produces Lucene query =     nodeName:hello metaTitle:hello
// Select all nodes where nodeName and metaTitle are "hello"
var searchResults = Searcher.Search(query);

-----------------------------------------------------

var searchCriteria = Searcher.CreateSearchCriteria();
var query = searchCriteria.Field("nodeName", "hello").And().Field("metaTitle", "hello");
// produces lucene query +nodeName:hello +metaTitle:hello
// give me results where nodeName MUST contain hello AND metaTitle MUST contain hello.
var searchResults = Searcher.search(query);

-----------------------------------------------------

var searchCriteria = Searcher.CreateSearchCriteria(BooleanOperation.Or);
var query = searchCriteria.Field("nodeName", "hello").And().Field("metaTitle", "hello");
// produces Lucene query =    nodeName:hello +metaTitle:hello
//  give me results where nodeName SHOULD contain hello AND metaTitle MUST contain hello
var searchResults = Searcher(query);

-----------------------------------------------------

var query = searchCriteria.GroupedOr(new string[] { "nodeName", "metaTitle" }, "hello").Compile();
// produces Lucene query =    (nodeName:hello metaTitle:hello)

-----------------------------------------------------

var query = searchCriteria.GroupedOr(new string[] { "nodeName", "metaTitle" }, new string[] { "hello","goodbye" });
// produces Lucene query =    (nodeName:hello metaTitle:goodbye)

-----------------------------------------------------
// FUZZY
// adding "..search...term".Fuzzy(0.5f) will return results for terms that are close to 
// what was search for to account for use mispellings. 0 to 1 is level of match closeness
var query = searchCriteria.Fields("nodeName","hello".Fuzzy(0.8f)).Compile();


// BOOSTING
// adding "..search...term".Boost() will boost the return for that particular term because 
// it is more relevant than other fields
var query = searchCriteria.Fields("nodeName","hello".Boost(8)).Or().Field("metaTitle","hello".Boost(5)).Compile();

----------------------------------------------------
var query = searchCriteria.Fields("nodeName","paging in XSLT").Compile();
nodeName:"paging in XSLT"

----------------------------------------------------
